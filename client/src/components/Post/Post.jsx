import PostItem from "../PostItem";

function Post({ posts, author }) {
  return (
    <div className="post-container">
      <div className="post-content">
        {posts.map(({ id, title, authorId }, index) => {
          return (
            <PostItem
              author={author}
              open={open}
              id={authorId}
              title={title}
              key={id + index + title}
            />
          );
        })}
      </div>
    </div>
  );
}

export default Post;
