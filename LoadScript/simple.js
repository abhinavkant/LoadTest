import http from 'k6/http';
import { check, sleep } from 'k6';

import { authenticateUser } from './auth.js';

const TENANT_ID = 'LoadTest';
const CLIENT_ID = 'LoadTestClient';
const CLIENT_SECRET = '7vTm5OVTUtOto0Yvwdqu9a5CeEsWGyBY';
const USERNAME = 'frank1';
const PASSWORD = 'password1';

export const options = {
    stages: [
        { duration: '10s', target: 20 },
        { duration: '30s', target: 500 },
        { duration: '30s', target: 5000 },
        { duration: '5m', target: 10000 },
        // { duration: '30s', target: 5000 },
        // { duration: '30s', target: 500 },
        // { duration: '10s', target: 20 },
    ],
};

// export function setup() {
//     return authenticateUser(TENANT_ID, CLIENT_ID, CLIENT_SECRET, "password", USERNAME, PASSWORD);
// }

export default function (data) {

    // const params = {
    //     headers: {
    //         'Content-Type': 'application/json',
    //         'Authorization': `Bearer ${data.access_token}`, // or `Bearer ${clientAuthResp.access_token}`
    //     },
    // };

    const res = http.get('https://localhost:8081/WeatherForecast');
    check(res,
        {
            'status was 200': (r) => r.status == 200,
            'duration < 300': (r) => r.timings.duration < 300
        });
    sleep(1);
}
