const jwt = require('jsonwebtoken');
const secretKey = 'admin1234';

function authenticateToken(req, res, next) {
 const authHeader = req.headers['authorization'];
 const token = authHeader && authHeader.split(' ')[1];

 if (token == null) {
   return res.status(401).json({error: 'Unauthorized request'}); // Unauthorized
 }
 jwt.verify(token, secretKey, (err, user) => {
   if (err) {
     return res.sendStatus(403); // Forbidden
   }

   req.user = user;
   next();
 });
}

module.exports = authenticateToken
