import React from 'react';
import { NavLink } from 'react-router-dom';
import SearchBar from '../SearchBar/SearchBar'; 
import './NavBar.css';
import logo from '../../assets/images/logo.png';

function Navbar({ showLogo = true, showNav = true, showSearch = true }) {
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
                    <NavLink to="/pets" className="nav-item active">Pet</NavLink>
                </nav>
            )}

            <div className="navbar-right">
                {showSearch && <SearchBar />}
            </div>

        </header>
    );
}

export default Navbar;