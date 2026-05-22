import React, { useState, useEffect } from 'react';
import './PetTable.css'; 
import { LuTrash, LuPencil } from 'react-icons/lu';

const PetTable = () => {
    const [appointments, setAppointments] = useState([]);
    const [currentPage, setCurrentPage] = useState(1);
    
    const ITEMS_PER_PAGE = 5;

    useEffect(() => {
        const mockData = [
            { id: 1, nome: 'Pituffinha Santos', especie: 'Gato', raca: 'SRD', dataNascimento: '05/03/2023', genero: 'Masculino' },
            { id: 2, nome: 'Panetone Santos', especie: 'Gato', raca: 'SRD', dataNascimento: '05/03/2023', genero: 'Feminino' },
            { id: 3, nome: 'Panetone Santos', especie: 'Gato', raca: 'SRD', dataNascimento: '05/03/2023', genero: 'Feminino' },
            { id: 4, nome: 'Rex', especie: 'Cachorro', raca: 'Labrador', dataNascimento: '10/01/2021', genero: 'Masculino' },
            { id: 5, nome: 'Luna', especie: 'Gato', raca: 'Siamês', dataNascimento: '15/08/2022', genero: 'Feminino' },
            { id: 6, nome: 'Thor', especie: 'Cachorro', raca: 'Pug', dataNascimento: '20/11/2023', genero: 'Masculino' },
            { id: 7, nome: 'Mia', especie: 'Gato', raca: 'Persa', dataNascimento: '02/02/2020', genero: 'Feminino' }
        ];
        setAppointments(mockData);
    }, []);

    const handleDelete = (id) => {
        console.log(`Preparando para deletar na API o registro com ID: ${id}`);
    };

    const handleEdit = (id) => {
        console.log(`Abrir modal de edição para o ID: ${id}`);
    };

    const totalPages = Math.ceil(appointments.length / ITEMS_PER_PAGE);
    const startIndex = (currentPage - 1) * ITEMS_PER_PAGE;
    const currentData = appointments.slice(startIndex, startIndex + ITEMS_PER_PAGE);
    const emptyRows = ITEMS_PER_PAGE - currentData.length;

    const handlePageChange = (page) => {
        setCurrentPage(page);
    };

    return (
        <div className="table-wrapper">
            <table className="muzzle-table">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Nome</th>
                        <th>Espécie</th>
                        <th>Raça</th>
                        <th>Data de Nascimento</th>
                        <th>Gênero</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {currentData.map((pet) => (
                        <tr key={pet.id}>
                            <td>{pet.id}</td>
                            <td>{pet.nome}</td>
                            <td>{pet.especie}</td>
                            <td>{pet.raca}</td>
                            <td>{pet.dataNascimento}</td>
                            <td>{pet.genero}</td>
                            <td className="actions">
                                <button className="btn-delete" onClick={() => handleDelete(pet.id)} title="Excluir">
                                    <LuTrash size={18} style={{ color: "var(--rosa-escuro)" }} />
                                </button>
                                <button className="btn-edit" onClick={() => handleEdit(pet.id)} title="Editar">
                                    <LuPencil size={18} style={{ color: "var(--azul-escuro)" }} />
                                </button>
                            </td>
                        </tr>
                    ))}
                    {emptyRows > 0 && Array.from({ length: emptyRows }).map((_, index) => (
                        <tr key={`empty-${index}`} className="empty-row">
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    ))}
                </tbody>
            </table>

            {totalPages > 1 && (
                <div className="pagination">
                    {Array.from({ length: totalPages }).map((_, index) => {
                        const pageNumber = index + 1;
                        return (
                            <span
                                key={pageNumber}
                                className={`page-number ${currentPage === pageNumber ? 'active' : ''}`}
                                onClick={() => handlePageChange(pageNumber)}
                            >
                                {pageNumber}
                            </span>
                        );
                    })}
                </div>
            )}
        </div>
    );
};

export default PetTable;