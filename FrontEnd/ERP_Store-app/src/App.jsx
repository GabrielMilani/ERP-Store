import './App.css'

import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import Home from './pages/Home/Home';
import About from './pages/About/About';
import Navbar from './components/Navbar/Navbar';
import Footer from './components/Footer/Footer';
import Product from './pages/Product/Product';
import Client from './pages/Client/Client';
import Sale from './pages/Sale/Sale';

function App() {

  return (
    <div className='App'>
      <BrowserRouter>
        <Navbar></Navbar>
        <div className="container">
          <Routes>
            <Route path="/" element={<Home />} >Home</Route>
            <Route path="/product" element={<Product />} >Product</Route>
            <Route path="/client" element={<Client />} >Client</Route>
            <Route path="/sale" element={<Sale />} >Sale</Route>
            <Route path="/about" element={<About />} >About</Route>
          </Routes>
        </div>
        <Footer></Footer>
      </BrowserRouter>
    </div>
  )
}

export default App
