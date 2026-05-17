import React from 'react';
import { LuSearch } from "react-icons/lu";
import '../NavBar/NavBar.css';

function SearchBar() {
    return (
        <div className="search-bar-container">
            <input 
                type="text" 
                placeholder="Faça sua pesquisa..." 
                className="search-bar-input"
            />
            <LuSearch size={20} className="search-bar-icon" />
        </div>
    );
}

export default SearchBar;