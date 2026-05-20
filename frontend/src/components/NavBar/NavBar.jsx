
import { NavLink } from 'react-router-dom';
import SearchBar from '../SearchBar/SearchBar'; 
import './NavBar.css';

function Navbar({ showLogo = true, showNav = true, showSearch = true }) {
    return (
        <header className="navbar-container">
            
            <div className="navbar-left">
                {showLogo && (
                    <h2 className="logo-text">Logo</h2>
                )}
            </div>

            {showNav && (
                <nav className="navbar-center-pill">
                    <NavLink to="/home" className="nav-item">Home</NavLink>
                    <NavLink to="/agendamento" className="nav-item">Agendamento</NavLink>
                    <NavLink to="/visualizar-pets" className="nav-item">Pet</NavLink>
                </nav>
            )}

            <div className="navbar-right">
                {showSearch && <SearchBar />}
            </div>

        </header>
    );
}

export default Navbar;