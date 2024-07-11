import { api, requestConfig } from "../utils/config";

const createProduct = async (data) => {
    const config = requestConfig("POST", data)

    try {
        const res = await fetch(api + "/products", config)
            .then((res) => res.json())
            .catch((err) => err)
        return res;
    } catch (error) {
        console.log(error);
    }
};

const getAllProduct = async () => {
    const config = requestConfig("GET")

    try {
        const res = await fetch(api + "/products", config)
            .then((res) => res.json())
            .catch((err) => err)
        return res;
    } catch (error) {
        console.log(error);
    }
};


const deleteProduct = async (id) => {
    const config = requestConfig("DELETE")

    try {
        const res = await fetch(api + "/products/" + id, config)
            .then((res) => res.json())
            .catch((err) => err)
        return res;
    } catch (error) {
        console.log(error);
    }
};

const updateProduct = async (data, id) => {
    const config = requestConfig("PUT", data)

    try {
        const res = await fetch(api + "/products/" + id, config)
            .then((res) => res.json())
            .catch((err) => err)
        return res;
    } catch (error) {
        console.log(error);
    }
};

const productService = {
    createProduct,
    getAllProduct,
    deleteProduct,
    updateProduct
};

export default productService;