import { useState } from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Login from './pages/Login.jsx';

/* Tem que instalar npm install react-router-dom para usar o BrowserRouter, Routes e Route */

function App() {

    return (
  <BrowserRouter>
    <Routes>
      <Route path='/' element={<Login />} />
    </Routes>
  </BrowserRouter>

  )
}

export default App;
