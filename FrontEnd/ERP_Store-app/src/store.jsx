import { configureStore } from '@reduxjs/toolkit'
import productReducer from './slices/productSlice'
import clientReducer from './slices/clientSlice'
import saleReducer from './slices/saleSlice'

export const store = configureStore({
    reducer: {
        product: productReducer,
        client: clientReducer,
        sale: saleReducer,
    },
})