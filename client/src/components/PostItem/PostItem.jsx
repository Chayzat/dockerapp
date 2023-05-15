import { useState } from "react";
import Modal from "../Modal";

function PostItem({ title, id, author }) {
  const [open, setOpen] = useState(false);
  const [curr, setCurr] = useState([]);
  return (
    <>
      <div
        className="post-box center"
        onClick={() => {
          setCurr(author.filter((au) => au.id === id));
          setOpen(!open);
        }}
      >
        <h3 className="post-title">{title.length < 40 ? title : "..."}</h3>
      </div>

      <Modal isOpen={open} onClose={() => setOpen(false)}>
        <Modal.Header>{open && curr[0].fullName}</Modal.Header>
        <Modal.Body>
          <div className="avatar-img">
            <img src={open ? curr[0].avatar : ""} alt="author avatar" />
          </div>
          <p>{title}</p>
        </Modal.Body>
      </Modal>
    </>
  );
}

export default PostItem;
