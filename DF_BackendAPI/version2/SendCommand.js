const express = require('express');
const dataModel = require("../shared/model.js");
const dbManager = require("../shared/db.connect.js");
const authenticateToken = require("../shared/jwtToken.js")
const router = express.Router();
const app = express();
app.use(express.json()); // Enable parsing JSON request bodies

  router.post('/',authenticateToken, (req, res) => {
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
  module.exports = router;