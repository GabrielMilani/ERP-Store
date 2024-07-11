import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import clientService from "../services/clientService";

const initialState = {
    clients: [],
    client: {},
    error: false,
    success: false,
    loading: false,
    message: null,
};

export const createClient = createAsyncThunk("client/create",
    async (client, thunkAPI) => {
        const data = await clientService.createClient(client)
        if (data.error) {
            return thunkAPI.rejectWithValue(data.errors[0]);
        }
        return data;
    }
);

export const getAllClients = createAsyncThunk("client",
    async () => {
        const data = await clientService.getAllClients();
        return data;
    }
);

export const deleteClient = createAsyncThunk("client/delete",
    async (id, thunkAPI) => {
        const data = await clientService.deleteClient(id)
        if (data.error) {
            return thunkAPI.rejectWithValue(data.errors[0]);
        }
        return data;
    }
);

export const updateClient = createAsyncThunk("product/update",
    async (clientData, thunkAPI) => {
        const data = await clientService.updateClient(clientData, clientData.id)
        if (data.error) {
            return thunkAPI.rejectWithValue(data.errors[0]);
        }
        return data;
    }
);



export const clientSlice = createSlice({
    name: "client",
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
            .addCase(createClient.pending, (state) => {
                state.loading = true;
                state.error = false;
            }).addCase(createClient.fulfilled, (state, action) => {
                state.loading = false;
                state.success = true;
                state.error = null;
                state.client = action.payload;
                state.clients.unshift(state.client);
                state.message = "Client adicionado com sucesso.";
            }).addCase(createClient.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload;
                state.client = {};
            }).addCase(getAllClients.pending, (state) => {
                state.loading = true;
                state.error = false;
            }).addCase(getAllClients.fulfilled, (state, action) => {
                state.loading = false;
                state.success = true;
                state.error = null;
                state.clients = action.payload;
            }).addCase(deleteClient.pending, (state) => {
                state.loading = true;
                state.error = false;
            }).addCase(deleteClient.fulfilled, (state, action) => {
                state.loading = false;
                state.success = true;
                state.error = null;
                state.clients = state.clients.filter((client) => {
                    return client.id !== action.payload.id;
                });
                state.message = "Cliente Removido com sucesso.";
            }).addCase(deleteClient.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload;
                state.client = {};
            }).addCase(updateClient.pending, (state) => {
                state.loading = true;
                state.error = false;
            }).addCase(updateClient.fulfilled, (state, action) => {
                state.loading = false;
                state.success = true;
                state.error = null;
                state.clients = state.clients.map((client) => {
                    if (client.id === action.payload.id) {
                        return client = action.payload
                    }
                    return client;
                });
                state.message = action.payload.message;;
            }).addCase(updateClient.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload;
                state.client = {};
            });



    }
});

export const { reset } = clientSlice.actions;
export default clientSlice.reducer;