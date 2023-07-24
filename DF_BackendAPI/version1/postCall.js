// const express = require('express');
// const app = express();
// app.use(express.json());
// const {dataSchema} = require("../shared/model.js");
// function send(){
// const router = express.Router();
// router.post('/api/posts', async (req, res) => {
//  try {
//    // Create a new post document using the request body
//    const newPost = new dataSchema(req.body);
//    console.log(newPost);

//    // Save the post to the database
//    const savedPost = await newPost.save();

//    // Send the response
//    res.status(201).json({ postId: savedPost._id });
//  } catch (error) {
//    // Handle any errors
//    console.error(error);
//    res.status(500).json({ error: 'Internal Server Error' });
//  }
// });
// }

// module.exports = {send};