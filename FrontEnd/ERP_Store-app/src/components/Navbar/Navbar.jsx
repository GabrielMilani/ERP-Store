import { Link, NavLink } from "react-router-dom"
import "./Navbar.css"

const Navbar = () => {
    return (
        <nav id="nav">
            <NavLink className="brand" to="/" >
                ERP <span>Store</span>
            </NavLink>
            <ul id="nav-links">
                <li>
                    <NavLink to="/">
                        Home
                    </NavLink>
                </li>
                <li>
                    <NavLink to="/product">
                        Product
                    </NavLink>
                </li>
                <li>
                    <NavLink to="/client">
                        Client
                    </NavLink>
                </li>
                <li>
                    <NavLink to="/sale">
                        Sale
                    </NavLink>
                </li>
                <li>
                    <NavLink to="/about">
                        About
                    </NavLink>
                </li>
            </ul>
        </nav>
    )
}

export default Navbar