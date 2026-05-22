
import './Modal.css';
import Title from '../Title/Title';

const Modal = ({ title, isOpen, onClose, children }) => {
    if (!isOpen) return null;

    return (
        <div className="modal-backdrop">
            <div className="modal-container">

                <div className="modal-header">
                    <Title title={title}showCloseButton={true} onCloseClick={onClose} />
                </div>

                <div className="modal-body">
                    {children}
                </div>

            </div>
        </div>
    );
};

export default Modal;