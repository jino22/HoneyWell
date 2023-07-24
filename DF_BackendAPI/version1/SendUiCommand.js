const express = require('express');
//const mongoose = require('mongoose');
const dbManager = require("../shared/db.connect.js");
const dataModel = require("../shared/Uimodel.js");
const authenticateToken = require("../shared/jwtToken.js")
const moment =require("moment");
// Create Express app
const router = express.Router();
const app = express();
app.use(express.json()); // Enable parsing JSON request bodies


//app.use("/Data");
// Define a route to get data from the collection
router.get('/', (req, res) => {
    dbManager.mongoConnect().then(async (conn) => {
     const date = moment().subtract(2, 'days').format("YYYY-MM-DD");
     console.log(date);
     dataModel.find({timestamp : {$gt : date}}).sort({_id:-1}).limit(10).then((data) => {
     res.json(data);
  })
  .catch((error) => {
    res.status(500).json({ error: 'Error retrieving data from MongoDB' });
  }); 
   })
});

  

router.post('/', (req, res) => {
    dbManager.mongoConnect().then(async (conn) => {
    const newData = new dataModel(req.body);
    console.log(newData);
    newData.save()
   .then(() => {
     res.status(201).json({ message: 'Data saved successfully' });
   })
   .catch((err) => {
     console.error('Error saving data:', err);
     res.status(500).json({ error: 'Failed to save data' });
   });
       });
  });
  // const port = 8080; // Choose the desired port number
  // app.listen(port, () => {
  //   console.log(`Server is listening on port ${port}`);
  // });
 

// // Start the server
// var server = app.listen(8080, function () {
//   var host = server.address().address 
//   var port = server.address().port
//   console.log("app listening at 8081");
// })

module.exports = router;