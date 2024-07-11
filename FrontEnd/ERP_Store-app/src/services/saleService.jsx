import { api, requestConfig } from "../utils/config";

const createSale = async (data) => {
    const config = requestConfig("POST", data)

    try {
        const res = await fetch(api + "/sales", config)
            .then((res) => res.json())
            .catch((err) => err)
        return res;
    } catch (error) {
        console.log(error);
    }
};

const getAllSales = async () => {
    const config = requestConfig("GET")

    try {
        const res = await fetch(api + "/sales", config)
            .then((res) => res.json())
            .catch((err) => err)
        return res;
    } catch (error) {
        console.log(error);
    }
};


const deleteSale = async (id) => {
    const config = requestConfig("DELETE")

    try {
        const res = await fetch(api + "/sales/" + id, config)
            .then((res) => res.json())
            .catch((err) => err)
        return res;
    } catch (error) {
        console.log(error);
    }
};

const updateSale = async (data, id) => {
    const config = requestConfig("PUT", data)

    try {
        const res = await fetch(api + "/sales/" + id, config)
            .then((res) => res.json())
            .catch((err) => err)
        return res;
    } catch (error) {
        console.log(error);
    }
};

const saleService = {
    createSale,
    getAllSales,
    deleteSale,
    updateSale
};

export default saleService;