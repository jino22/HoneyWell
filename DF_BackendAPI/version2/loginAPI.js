const express = require('express');
const router = express.Router();
const jwt = require('jsonwebtoken')
const secretKey = 'admin1234';
router.post('/', (req, res) => {
    // Perform your authentication logic
   
    // If authentication is successful, generate and send JWT token
    const user = { username: 'Admin', password: 'Admin@1234' };
    const token = jwt.sign(user, secretKey,{ expiresIn: '5m' });
   
    res.json({ token: token });
   });
module.exports = router;