export async function apiPOST(uri, data) {
    const rawResponse = await fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    });

    const response = await rawResponse.json();

    return response;
}

export async function apiGET(uri) {
    const rawResponse = await fetch(uri, {
        method: 'GET',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    });

    const response = await rawResponse.json();

    return response;
}