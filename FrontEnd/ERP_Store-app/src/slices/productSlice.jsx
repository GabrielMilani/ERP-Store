import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import productService from "../services/productService";
import Product from './../pages/Product/Product';

const initialState = {
    products: [],
    product: {},
    error: false,
    success: false,
    loading: false,
    message: null,
};

export const createProduct = createAsyncThunk("product/create",
    async (product, thunkAPI) => {
        const data = await productService.createProduct(product)
        if (data.error) {
            return thunkAPI.rejectWithValue(data.errors[0]);
        }
        return data;
    }
);

export const getAllProduct = createAsyncThunk("product",
    async () => {
        const data = await productService.getAllProduct();
        return data;
    }
);

export const deleteProduct = createAsyncThunk("product/delete",
    async (id, thunkAPI) => {
        const data = await productService.deleteProduct(id)
        if (data.error) {
            return thunkAPI.rejectWithValue(data.errors[0]);
        }
        return data;
    }
);

export const updateProduct = createAsyncThunk("product/update",
    async (productData, thunkAPI) => {
        const data = await productService.updateProduct(productData, productData.id)
        if (data.error) {
            return thunkAPI.rejectWithValue(data.errors[0]);
        }
        return data;
    }
);



export const productSlice = createSlice({
    name: "product",
    initialState,
    reducers: {
        reset: (state) => {
            state.loading = false;
            state.error = false;
            state.success = false;
        },
    },
    extraReducers: (builder) => {
        builder
            .addCase(createProduct.pending, (state) => {
                state.loading = true;
                state.error = false;
            }).addCase(createProduct.fulfilled, (state, action) => {
                state.loading = false;
                state.success = true;
                state.error = null;
                state.product = action.payload;
                state.products.unshift(state.product);
                state.message = "Produto adicionado com sucesso.";
            }).addCase(createProduct.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload;
                state.product = {};
            }).addCase(getAllProduct.pending, (state) => {
                state.loading = true;
                state.error = false;
            }).addCase(getAllProduct.fulfilled, (state, action) => {
                state.loading = false;
                state.success = true;
                state.error = null;
                state.products = action.payload;
            }).addCase(deleteProduct.pending, (state) => {
                state.loading = true;
                state.error = false;
            }).addCase(deleteProduct.fulfilled, (state, action) => {
                state.loading = false;
                state.success = true;
                state.error = null;
                state.products = state.products.filter((product) => {
                    return product.id !== action.payload.id;
                });
                state.message = "Produto Removido com sucesso.";
            }).addCase(deleteProduct.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload;
                state.product = {};
            }).addCase(updateProduct.pending, (state) => {
                state.loading = true;
                state.error = false;
            }).addCase(updateProduct.fulfilled, (state, action) => {
                state.loading = false;
                state.success = true;
                state.error = null;
                state.products = state.products.map((product) => {
                    if (product.id === action.payload.id) {
                        return product = action.payload
                    }
                    return product;
                });
                state.message = action.payload.message;;
            }).addCase(updateProduct.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload;
                state.product = {};
            });



    }
});

export const { reset } = productSlice.actions;
export default productSlice.reducer;