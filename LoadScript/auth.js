import http from 'k6/http'

export function authenticateUser(tenantId, clientId, clientSecret, grantType, scope, resource) {
    let url = `https://local.host.dev:8010/realms/${tenantId}/protocol/openid-connect/token`;

    const requestBody = {
        client_id: clientId,
        client_secret: clientSecret,
        scope: scope,
    };

    if (grantType === 'client_credentials') {
        requestBody['grant_type'] = grantType;
    }
    else if (grantType === 'password') {
        requestBody['grant_type'] = grantType;
        requestBody['username'] = resource.username;
        requestBody['password'] = resource.password;
    } else {
        throw `grantType = ${grantType} not supported to fetch access token`
    }

    const reponse = http.post(url, requestBody)
    return reponse.json();
}