const express = require('express');
const router = express.Router();
//const jwt = require('jsonwebtoken')
const dbManager = require("../shared/db.connect.js");
const decryptionFunction = require('js-base64');
const crypto = require('crypto')
const mongoose = require('mongoose');
//const Schema = require("mongoose").Schema;
const userSchema = new mongoose.Schema({
    id: String,
    password: String,
   });
   
   const User = mongoose.model('loginids', userSchema);
   
router.post('/', async (req, res) => {
    const { id, password } = req.body;
    try {
      dbManager.mongoConnect().then(async (conn) => {
      const user = await User.findOne({ id, password }).exec();
      
      if (user) {
        return res.json({ message: 'Login successful' });
      }
   
      return res.status(401).json({ message: 'Invalid credentials' });
    })
    } catch (error) {
      console.error('Error searching for ID and password:', error);
      return res.status(500).json({ message: 'Internal server error' });
    }
   });

module.exports = router;