import { NavLink, useNavigate } from 'react-router-dom'; 
import SearchBar from '../SearchBar/SearchBar'; 
import './NavBar.css';
import logo from '../../assets/images/logo.png';
import Swal from 'sweetalert2'; 

function Navbar({ showLogo = true, showNav = true, showSearch = true }) {
    const navigate = useNavigate(); 


    const handleLogout = (e) => {
        e.preventDefault(); 

        Swal.fire({
            title: 'Deseja sair?',
            text: "Não esqueça de marcar a consulta veterinária do seu pet antes de sair.",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: 'var(--rosa-escuro)', 
            cancelButtonColor: '#6c757d',
            confirmButtonText: 'Sim, desejo sair',
            cancelButtonText: 'Cancelar'
        }).then((result) => {
            if (result.isConfirmed) {
                localStorage.removeItem('user');
                navigate('/');
            }
        });
    };

    return (
        <header className="navbar-container">
            
            <div className="navbar-left">
                {showLogo && (
                    <img src={logo} alt="Logo" />
                )}
            </div>

            {showNav && (
                <nav className="navbar-center-pill">
                    <NavLink to="/home" className="nav-item">Home</NavLink>
                    <NavLink to="/pets" className="nav-item">Pet</NavLink>
                    
                    
                    <a href="/" onClick={handleLogout} className="nav-item">
                        Logout
                    </a>
                </nav>
            )}

            <div className="navbar-right">
                {showSearch && <SearchBar />}
            </div>

        </header>
    );
}

export default Navbar;