import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
    stages: [
        { duration: '10s', target: 20 },
        { duration: '30s', target: 500 },
        // { duration: '30s', target: 5000 },
        { duration: '5m', target: 10000 },
        { duration: '30s', target: 5000 },
        { duration: '30s', target: 500 },
        { duration: '10s', target: 20 },
    ],
};

export default function () {
    const res = http.get('https://localhost:8081/WeatherForecast');
    check(res,
        {
            'status was 200': (r) => r.status == 200,
            'duration < 300': (r) => r.timings.duration < 300
        });
    sleep(1);
}
