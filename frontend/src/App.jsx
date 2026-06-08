import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Login from './pages/Login.jsx';
import OwnerRegister from './pages/OwnerRegister';
import PetVisualizer from './pages/PetVisualizer';
import Home from './pages/Home';
import './styles/global.css';
import ProtectedRoute from './ProtectedRoute.jsx';

/* Tem que instalar npm install react-router-dom para usar o BrowserRouter, Routes e Route */

function App() {

    return (
  <BrowserRouter>
    <Routes>
      <Route path='/' element={<Login />} />
      <Route path='/novo-usuario' element={<OwnerRegister />} />

      {/* As rotas abaixo são privadas - Precisa do Login */}
      <Route path='/pets' element={
        <ProtectedRoute>
          <PetVisualizer />
        </ProtectedRoute>
      } />
      <Route path='/home' element={
        <ProtectedRoute>
          <Home />
        </ProtectedRoute>
      } />
      <Route path='/agendamento' element={
        <ProtectedRoute>
          <Home />
        </ProtectedRoute>
      } />
    </Routes>
  </BrowserRouter>

  )
}

export default App;
