import { animated, useSpring, useTransition } from "@react-spring/web";
import stylesCss from "./Modal.module.css";
import { useEffect, createContext, useContext } from "react";
import cn from "classnames";

const ModalContext = createContext();

function Modal({ children, isOpen, onClose }) {
  const handleEscape = (e) => {
    if (e.keyCode === 27) {
      onClose();
    }
  };

  useEffect(() => {
    document.addEventListener("keydown", handleEscape);

    return () => document.removeEventListener("keydown", handleEscape);
  }, []);
  const modalTransition = useTransition(isOpen, {
    from: { opacity: 0 },
    enter: { opacity: 1 },
    leave: { opacity: 1 },
    config: {
      duration: 300,
    },
  });
  const spring = useSpring({
    opacity: isOpen ? 1 : 0,
    transform: isOpen ? "translateY(0%)" : "translateY(-100%)",
    config: {
      duration: 300,
    },
  });
  return modalTransition(
    (styles, isOpen) =>
      isOpen && (
        <animated.div
          style={styles}
          className={stylesCss.reactModalOverlay}
          onClick={onClose}
        >
          <animated.div
            style={spring}
            className={stylesCss.reactModalWrapper}
            onClick={(e) => e.stopPropagation()}
          >
            <div className={stylesCss.reactModalContent}>
              <ModalContext.Provider value={{ onClose }}>
                {children}
              </ModalContext.Provider>
            </div>
          </animated.div>
        </animated.div>
      )
  );
}

const DismissButton = ({ children, className }) => {
  const { onClose } = useContext(ModalContext);

  return (
    <button type="button" className={className} onClick={onClose}>
      {children}
    </button>
  );
};

const ModalHeader = ({ children }) => {
  return (
    <div className={stylesCss.reactModalHeader}>
      <div className={stylesCss.reactModalTitle}>{children}</div>
      <DismissButton
        className={cn(stylesCss.btnClose, "form__heading-btn close-btn")}
      >
        &times;
      </DismissButton>
    </div>
  );
};

const ModalBody = ({ children }) => {
  return <div className={stylesCss.reactModalBody}>{children}</div>;
};

const ModalFooter = ({ children }) => {
  return <div className={stylesCss.reactModalFooter}>{children}</div>;
};

Modal.Header = ModalHeader;
Modal.Body = ModalBody;
Modal.Footer = ModalFooter;
Modal.DismissButton = DismissButton;

export default Modal;
