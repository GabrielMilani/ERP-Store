import "./Client.css"
import { useDispatch, useSelector } from "react-redux";
import { useEffect, useRef, useState } from "react";
import { createClient, deleteClient, getAllClients, updateClient } from "../../slices/clientSlice";
import { BsPencilFill, BsXLg } from "react-icons/bs";

const Client = () => {
    const [name, setName] = useState("");
    const [email, setEmail] = useState("");

    const [editId, setEditId] = useState("");
    const [editName, setEditName] = useState("");
    const [editEmail, setEditEmail] = useState("");

    const dispatch = useDispatch();

    const { clients, loading, error, message } = useSelector((state) => state.client);

    const newClientForm = useRef();
    const editClientForm = useRef();

    useEffect(() => {
        dispatch(getAllClients());
    }, [dispatch])

    const handleSubmit = (e) => {
        e.preventDefault();

        const clientData = {
            name,
            email,
        }
        dispatch(createClient(clientData));
    }

    const handleDelete = (id) => {
        dispatch(deleteClient(id))
    }

    const hideOrShowForms = () => {
        newClientForm.current.classList.toggle("hide");
        editClientForm.current.classList.toggle("hide");
    }

    const handleUpdate = (e) => {
        e.preventDefault();

        const clientUpdateData = {
            id: editId,
            name: editName,
            email: editEmail,
        }
        dispatch(updateClient(clientUpdateData));
    }

    const handleEdit = (client) => {
        if (editClientForm.current.classList.contains("hide")) {
            hideOrShowForms();
        }

        setEditId(client.id);
        setEditName(client.name);
        setEditEmail(client.email);
    }

    const handleCancelEdit = () => {
        hideOrShowForms();
    }


    if (loading) {
        return <p>Carregando...</p>
    }

    return (
        <>
            <div id="new-client" ref={newClientForm}>
                <h2>Cadastro de Clientes</h2>
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
                        <span>Email:</span>
                        <input
                            type="text"
                            placeholder="E-mail"
                            onChange={(e) => setEmail(e.target.value)}
                            value={email}
                        />
                    </label>
                    <input
                        type="submit"
                        value="Salvar"
                    />
                </form>
            </div>

            <div id="edit-client" className="edit-client hide" ref={editClientForm}>
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
                        <span>Email:</span>
                        <input
                            type="text"
                            placeholder="Email"
                            onChange={(e) => setEditDescription(e.target.value)}
                            value={editEmail}
                        />
                    </label>
                    <input type="submit" value="Salvar" />
                    <button className="cancel-btn" onClick={handleCancelEdit}>Cancelar</button>
                </form>
            </div>

            <div className="client-list">
                <h3 className="title">Produtos já Cadastrados.</h3>
                {clients && clients.map((client) => (
                    <div className="client" key={client.id}>
                        <h3>{client.id} - {client.name}</h3>
                        <p>{client.email}</p>
                        <BsPencilFill onClick={() => handleEdit(client)} />
                        <BsXLg onClick={() => handleDelete(client.id)} />
                    </div>
                ))}
            </div>

        </>
    )
}

export default Client