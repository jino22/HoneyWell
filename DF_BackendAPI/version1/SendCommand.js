const express = require('express');
const {dataSchema} = require("../shared/model.js");
const dbManager = require("../shared/db.connect.js");
const router = express.Router();
const app = express();
app.use(express.json()); // Enable parsing JSON request bodies

  router.post('/', (req, res) => {
    dbManager.mongoConnect().then(async (conn) => {
    const newData = new dataSchema(req.body);
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
  module.exports = router;