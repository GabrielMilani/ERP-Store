import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import saleService from "../services/saleService";

const initialState = {
    sales: [],
    sale: {},
    error: false,
    success: false,
    loading: false,
    message: null,
};

export const createSale = createAsyncThunk("sale/create",
    async (sale, thunkAPI) => {
        const data = await saleService.createSale(sale)
        if (data.error) {
            return thunkAPI.rejectWithValue(data.errors[0]);
        }
        return data;
    }
);

export const getAllSales = createAsyncThunk("sale",
    async () => {
        const data = await saleService.getAllSales();
        return data;
    }
);

export const deleteSale = createAsyncThunk("sale/delete",
    async (id, thunkAPI) => {
        const data = await saleService.deleteSale(id)
        if (data.error) {
            return thunkAPI.rejectWithValue(data.errors[0]);
        }
        return data;
    }
);

export const updateSale = createAsyncThunk("sale/update",
    async (saleData, thunkAPI) => {
        const data = await saleService.updateSale(saleData, saleData.id)
        if (data.error) {
            return thunkAPI.rejectWithValue(data.errors[0]);
        }
        return data;
    }
);



export const saleSlice = createSlice({
    name: "sale",
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
            .addCase(createSale.pending, (state) => {
                state.loading = true;
                state.error = false;
            }).addCase(createSale.fulfilled, (state, action) => {
                state.loading = false;
                state.success = true;
                state.error = null;
                state.sale = action.payload;
                state.sales.unshift(state.sale);
                state.message = "Produto adicionado com sucesso.";
            }).addCase(createSale.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload;
                state.sale = {};
            }).addCase(getAllSales.pending, (state) => {
                state.loading = true;
                state.error = false;
            }).addCase(getAllSales.fulfilled, (state, action) => {
                state.loading = false;
                state.success = true;
                state.error = null;
                state.sales = action.payload;
            }).addCase(deleteSale.pending, (state) => {
                state.loading = true;
                state.error = false;
            }).addCase(deleteSale.fulfilled, (state, action) => {
                state.loading = false;
                state.success = true;
                state.error = null;
                state.sales = state.sales.filter((sale) => {
                    return sale.id !== action.payload.id;
                });
                state.message = "Venda Removida com sucesso.";
            }).addCase(deleteSale.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload;
                state.sale = {};
            }).addCase(updateSale.pending, (state) => {
                state.loading = true;
                state.error = false;
            }).addCase(updateSale.fulfilled, (state, action) => {
                state.loading = false;
                state.success = true;
                state.error = null;
                state.sales = state.sales.map((sale) => {
                    if (sale.id === action.payload.id) {
                        return sale = action.payload
                    }
                    return sale;
                });
                state.message = action.payload.message;;
            }).addCase(updateSale.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload;
                state.sale = {};
            });



    }
});

export const { reset } = saleSlice.actions;
export default saleSlice.reducer;