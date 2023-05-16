import { useState, useEffect } from "react";
import axios from "axios";
import { TailSpin } from "react-loader-spinner";
import Footer from "./components/Footer";
import Header from "./components/Header";
import Left from "./components/Left";
import Post from "./components/Post/Post";
import Right from "./components/Right";

function App() {
  const [posts, setPosts] = useState([]);
  const [author, setAuthor] = useState([]);
  const data = () => {
    axios
      .get(import.meta.env.VITE_HOST)
      .then((result) => {
        setPosts(result.data.posts);
      })
      .catch((err) => {
        console.error(err);
      });
  };
  const authors = () => {
    axios
    .get(import.meta.env.VITE_AUTH)
    .then((result) => {
      setAuthor(result.data);
    })
    .catch((err) => {
      console.error(err);
    });
  }
  useEffect(() => {
    data();
    authors();
  }, []);
  return (
    <div className="wrapper">
      <Header />
      <Left />
      <main className="main">
        {posts.length ? (
          <Post posts={posts} author={author}/>
        ) : (
          <div className="spin-container center">
            <TailSpin
              height="80"
              width="80"
              color="grey"
              ariaLabel="tail-spin-loading"
              radius="1"
              visible={true}
            />
          </div>
        )}
      </main>
      <Right />
      <Footer />
    </div>
  );
}

export default App;
