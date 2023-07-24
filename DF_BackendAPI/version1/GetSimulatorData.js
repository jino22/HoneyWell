// Import dependencies
const express = require('express');
//const mongoose = require('mongoose');
const dbManager = require("../shared/db.connect.js");
const {dataSchema} = require("../shared/model.js");
const authenticateToken = require("../shared/jwtToken.js")
const moment = require("moment");
// Create Express app
const router = express.Router();

//app.use("/Data");
// Define a route to get data from the collection
router.get('/', (req, res) => {
  if(!req.query.date){
    return res.status(400).json({error : 'Date is reqiured'});
  }
    dbManager.mongoConnect().then(async (conn) => {
    const dateParam = req.query.date;
      // Determine the date based on the provided parameter
      let query;
      if (dateParam === 'TODAY') {
        const today = moment().format('YYYY-MM-DD');
        query = { timestamp: { $gte: today } };
      } else if (dateParam === 'YESTERDAY') {
        const yesterday = moment().subtract(1, 'days').format('YYYY-MM-DD');
        const today = moment().format('YYYY-MM-DD');
        query = { timestamp:{$gte : yesterday,$lt : today} };
      } else if (dateParam === 'LASTWEEK') {
        const lastWeek = moment().subtract(1, 'weeks').format('YYYY-MM-DD');
        query = { timestamp: { $gte: lastWeek } };
      } else {
        return res.status(400).json({ error: 'Invalid date parameter' });
      }
      dataSchema.find(query).sort({_id:-1}).limit(100).then((data) => {
    res.json(data);
   })
   .catch((error) => {
     res.status(500).json({ error: 'Error retrieving data from MongoDB' });
   }); 
    })
});

// // Start the server
// var server = app.listen(8080, function () {
//   var host = server.address().address 
//   var port = server.address().port
//   console.log("app listening at 8081");
// })

module.exports = router;