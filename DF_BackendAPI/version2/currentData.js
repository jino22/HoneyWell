// Import dependencies
const express = require('express');
//const mongoose = require('mongoose');
const dbManager = require("../shared/db.connect.js");
const dataModel = require("../shared/model.js");
const authenticateToken = require("../shared/jwtToken.js")
// Create Express app
const router = express.Router();

// Define a route to get data from the collection
router.get('/',authenticateToken, (req, res) => {
     dbManager.mongoConnect().then(async (conn) => {
     dataModel.find().sort({timestamp:-1}).limit(1).then((data) => {
     console.log(data)
     var currentData =[ {
        "temperature" :data[0].temperature,
        "humidity" : data[0].humidity,
        "iaq": data[0].iaq
     }]
       
      res.json(currentData);
   }).catch((error) => {
     res.status(500).json({ error: 'Error retrieving data from MongoDB' });
   });
    })
});

module.exports = router;