export const api = "https://localhost:7021/api";

export const requestConfig = (method, data) => {
    let config;

    config = {
        method,
        body: JSON.stringify(data),
        headers: {
            "Content-Type": "application/json"
        }
    }

    return config;
};