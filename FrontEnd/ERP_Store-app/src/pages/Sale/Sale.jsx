import "./Sale.css"
import { useDispatch, useSelector } from "react-redux";
import { useEffect, useRef, useState } from "react";
import { createSale, deleteSale, getAllSales, updateSale } from "../../slices/saleSlice";
import { BsPencilFill, BsXLg } from "react-icons/bs";

const Sale = () => {
    const [clientId, setClientId] = useState("");
    const [productId, setProductId] = useState("");
    const [soldQuantity, setSoldQuantity] = useState(0);

    const [editId, setEditId] = useState("");
    const [editClientId, setEditClientId] = useState("");
    const [editProductId, setEditProductId] = useState("");
    const [editSoldQuantity, setEditSoldQuantity] = useState(0);

    const dispatch = useDispatch();

    const { sales, loading, error, message } = useSelector((state) => state.sale);

    const newSaleForm = useRef();
    const editSaleForm = useRef();

    useEffect(() => {
        dispatch(getAllSales());
    }, [dispatch])

    const handleSubmit = (e) => {
        e.preventDefault();

        const saleData = {
            clientId,
            productId,
            soldQuantity
        }
        dispatch(createSale(saleData));
    }

    const handleDelete = (id) => {
        dispatch(deleteSale(id))
    }

    const hideOrShowForms = () => {
        newSaleForm.current.classList.toggle("hide");
        editSaleForm.current.classList.toggle("hide");
    }

    const handleUpdate = (e) => {
        e.preventDefault();

        const saleUpdateData = {
            id: editId,
            clientId: editClientId,
            productId: editProductId,
            soldQuantity: editSoldQuantity
        }
        console.log(saleUpdateData)
        dispatch(updateSale(saleUpdateData));
    }

    const handleEdit = (sale) => {
        if (editSaleForm.current.classList.contains("hide")) {
            hideOrShowForms();
        }
        console.log(sale)
        setEditId(sale.id);
        setEditClientId(sale.clientId);
        setEditProductId(sale.productId);
        setEditSoldQuantity(sale.soldQuantity)
    }

    const handleCancelEdit = () => {
        hideOrShowForms();
    }


    if (loading) {
        return <p>Carregando...</p>
    }

    return (
        <>
            <div id="new-sale" ref={newSaleForm}>
                <h2>Venda de Produtos</h2>
                <form onSubmit={handleSubmit}>
                    <label>
                        <span>ClientId:</span>
                        <input
                            type="text"
                            placeholder="ClientId"
                            onChange={(e) => setClientId(e.target.value)}
                            value={clientId}
                        />
                    </label>
                    <label>
                        <span>ProductId:</span>
                        <input
                            type="text"
                            placeholder="ProductId"
                            onChange={(e) => setProductId(e.target.value)}
                            value={productId}
                        />
                    </label>
                    <label>
                        <span>Quantidade:</span>
                        <input
                            type="number"
                            placeholder="Quantidade"
                            onChange={(e) => setSoldQuantity(e.target.value)}
                            value={soldQuantity}
                        />
                    </label>
                    <input
                        type="submit"
                        value="Vender"
                    />
                </form>
            </div>

            <div id="edit-sale" className="edit-sale hide" ref={editSaleForm}>
                <form onSubmit={handleUpdate}>
                    <label>
                        <span>ClientId:</span>
                        <input
                            type="text"
                            placeholder="ClientId"
                            onChange={(e) => setEditClientId(e.target.value)}
                            value={editClientId}
                        />
                    </label>
                    <label>
                        <span>ProductId:</span>
                        <input
                            type="text"
                            placeholder="ProductId"
                            onChange={(e) => setEditProductId(e.target.value)}
                            value={editProductId}
                        />
                    </label>
                    <label>
                        <span>Quantidade:</span>
                        <input
                            type="number"
                            placeholder="Quantidade"
                            onChange={(e) => setEditSoldQuantity(e.target.value)}
                            value={editSoldQuantity}
                        />
                    </label>
                    <input type="submit" value="Salvar" />
                    <button className="cancel-btn" onClick={handleCancelEdit}>Cancelar</button>
                </form>
            </div>

            <div className="sale-list">
                <h3 className="title">Vendas já Cadastradas.</h3>
                {sales && sales.map((sale) => (
                    <div className="sale" key={sale.id}>
                        <h3>Venda de numero: {sale.id}</h3>
                        <h4>
                            <span>Client de ID: </span>
                            {sale.clientId}
                        </h4>
                        <h4>
                            <span>Producto de ID: </span>
                            {sale.productId}
                        </h4>
                        <h4>
                            <span>Quatidade Vendida: </span>
                            {sale.soldQuantity}
                        </h4>
                        <BsPencilFill onClick={() => handleEdit(sale)} />
                        <BsXLg onClick={() => handleDelete(sale.id)} />
                    </div>
                ))}
            </div>

        </>
    )
}

export default Sale