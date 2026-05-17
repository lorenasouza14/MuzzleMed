import { useState } from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Login from './pages/Login.jsx';
import OwnerRegister from './pages/OwnerRegister';
import PetVisualizer from './pages/PetVisualizer';
import Navbar from './components/NavBar/NavBar';
import './styles/global.css';

/* Tem que instalar npm install react-router-dom para usar o BrowserRouter, Routes e Route */

function App() {

    return (
  <BrowserRouter>
    <Routes>
      <Route path='/' element={<Login />} />
      <Route path='/novo-usuario' element={<OwnerRegister />} />
      <Route path='/visualizar-pets' element={<PetVisualizer />} />
    </Routes>
  </BrowserRouter>

  )
}

export default App;
