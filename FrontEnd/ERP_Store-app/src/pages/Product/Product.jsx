import { useEffect, useState } from "react";
import "./Product.css"
import { createProduct, getAllProduct, deleteProduct, updateProduct } from './../../slices/productSlice';
import { useSelector, useDispatch } from "react-redux";
import { BsFillEyeFill, BsPencilFill, BsXLg } from "react-icons/bs";
import { useRef } from "react";

const Product = () => {
    const [name, setName] = useState("");
    const [description, setDescription] = useState("");
    const [price, setPrice] = useState(0);
    const [quantity, setQuantity] = useState(0);

    const [editId, setEditId] = useState("");
    const [editName, setEditName] = useState("");
    const [editDescription, setEditDescription] = useState("");
    const [editPrice, setEditPrice] = useState(0);
    const [editQuantity, setEditQuantity] = useState(0);

    const dispatch = useDispatch();

    const { products, loading, error, message } = useSelector((state) => state.product);

    const newProductForm = useRef();
    const editProductForm = useRef();

    useEffect(() => {
        dispatch(getAllProduct());
    }, [dispatch])

    const handleSubmit = (e) => {
        e.preventDefault();

        const productData = {
            name,
            description,
            price,
            quantity
        }
        dispatch(createProduct(productData));
    }

    const handleDelete = (id) => {
        dispatch(deleteProduct(id))
    }

    const hideOrShowForms = () => {
        newProductForm.current.classList.toggle("hide");
        editProductForm.current.classList.toggle("hide");
    }

    const handleUpdate = (e) => {
        e.preventDefault();

        const productUpdateData = {
            id: editId,
            name: editName,
            description: editDescription,
            price: editPrice,
            quantity: editQuantity
        }
        console.log(productUpdateData)
        dispatch(updateProduct(productUpdateData));
    }

    const handleEdit = (product) => {
        if (editProductForm.current.classList.contains("hide")) {
            hideOrShowForms();
        }

        setEditId(product.id);
        setEditName(product.name);
        setEditDescription(product.description);
        setEditPrice(product.price)
        setEditQuantity(product.quantity)
    }

    const handleCancelEdit = () => {
        hideOrShowForms();
    }


    if (loading) {
        return <p>Carregando...</p>
    }

    return (
        <>
            <div id="new-product" ref={newProductForm}>
                <h2>Cadastro de Produtos</h2>
                <form onSubmit={handleSubmit}>
                    <label>
                        <span>Nome:</span>
                        <input
                            type="text"
                            placeholder="Nome"
                            onChange={(e) => setName(e.target.value)}
                            value={name}
                        />
                    </label>
                    <label>
                        <span>Descrição:</span>
                        <input
                            type="text"
                            placeholder="Descrição"
                            onChange={(e) => setDescription(e.target.value)}
                            value={description}
                        />
                    </label>
                    <label>
                        <span>Preço:</span>
                        <input
                            type="number"
                            placeholder="Preço"
                            onChange={(e) => setPrice(e.target.value)}
                            value={price}
                        />
                    </label>
                    <label>
                        <span>Quantidade:</span>
                        <input
                            type="number"
                            placeholder="Quantidade"
                            onChange={(e) => setQuantity(e.target.value)}
                            value={quantity}
                        />
                    </label>
                    <input
                        type="submit"
                        value="Salvar"
                    />
                </form>
            </div>

            <div id="edit-product" className="edit-product hide" ref={editProductForm}>
                <form onSubmit={handleUpdate}>
                    <label>
                        <span>Nome:</span>
                        <input
                            type="text"
                            placeholder="Nome"
                            onChange={(e) => setEditName(e.target.value)}
                            value={editName}
                        />
                    </label>
                    <label>
                        <span>Descrição:</span>
                        <input
                            type="text"
                            placeholder="Descrição"
                            onChange={(e) => setEditDescription(e.target.value)}
                            value={editDescription}
                        />
                    </label>
                    <label>
                        <span>Preço:</span>
                        <input
                            type="number"
                            placeholder="Preço"
                            onChange={(e) => setEditPrice(e.target.value)}
                            value={editPrice}
                        />
                    </label>
                    <label>
                        <span>Quantidade:</span>
                        <input
                            type="number"
                            placeholder="Quantidade"
                            onChange={(e) => setEditQuantity(e.target.value)}
                            value={editQuantity}
                        />
                    </label>
                    <input type="submit" value="Salvar" />
                    <button className="cancel-btn" onClick={handleCancelEdit}>Cancelar</button>
                </form>
            </div>

            <div className="product-list">
                <h3 className="title">Produtos já Cadastrados.</h3>
                {products && products.map((product) => (
                    <div className="product" key={product.id}>
                        <h3>{product.id} - {product.name}</h3>
                        <p>{product.description}</p>
                        <h4>
                            <span>Preço: </span>
                            {product.price}
                        </h4>
                        <h4>
                            <span>Quantidade: </span>
                            {product.quantity}
                        </h4>
                        <BsPencilFill onClick={() => handleEdit(product)} />
                        <BsXLg onClick={() => handleDelete(product.id)} />
                    </div>
                ))}
            </div>

        </>
    )
}

export default Product