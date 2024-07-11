import { api, requestConfig } from "../utils/config";

const createClient = async (data) => {
    const config = requestConfig("POST", data)

    try {
        const res = await fetch(api + "/clients", config)
            .then((res) => res.json())
            .catch((err) => err)
        return res;
    } catch (error) {
        console.log(error);
    }
};

const getAllClients = async () => {
    const config = requestConfig("GET")

    try {
        const res = await fetch(api + "/clients", config)
            .then((res) => res.json())
            .catch((err) => err)
        return res;
    } catch (error) {
        console.log(error);
    }
};


const deleteClient = async (id) => {
    const config = requestConfig("DELETE")

    try {
        const res = await fetch(api + "/clients/" + id, config)
            .then((res) => res.json())
            .catch((err) => err)
        return res;
    } catch (error) {
        console.log(error);
    }
};

const updateClient = async (data, id) => {
    const config = requestConfig("PUT", data)

    try {
        const res = await fetch(api + "/clients/" + id, config)
            .then((res) => res.json())
            .catch((err) => err)
        return res;
    } catch (error) {
        console.log(error);
    }
};

const productService = {
    createClient,
    getAllClients,
    deleteClient,
    updateClient
};

export default productService;