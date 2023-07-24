// const crypto = require('crypto');
 
// const algorithm = 'aes-256-cbc';
 
// const key = crypto.randomBytes(32);
 
// const iv = crypto.randomBytes(16);
 
// function encrypt(text) {
//     let cipher = crypto.createCipheriv(algorithm, Buffer.from(key), iv);
//     let encrypted = cipher.update(text);
//     encrypted = Buffer.concat([encrypted, cipher.final()]);
//     return { iv: iv.toString('hex'),
//     encryptedData: encrypted.toString('hex') };
// }

// var encrypted = encrypt("Amar");
// console.log(encrypted)
 
// function decrypt(text) {
//     let iv = Buffer.from(text.iv, 'hex');
//     let encryptedText = Buffer.from(text.encryptedData, 'hex');
 
//     let decipher = crypto.createDecipheriv(algorithm, Buffer.from(key), iv);
 
//     let decrypted = decipher.update(encryptedText);
//     decrypted = Buffer.concat([decrypted, decipher.final()]);
 
//     return decrypted.toString();
// }
 
// const decrypted = decrypt(encrypted)
// console.log("Decrypted Text: " + decrypted); 

const crypto = require('crypto');

// Encrypt function
function encrypt(text, secretKey) {
 const salt = crypto.randomBytes(16);
 const key = crypto.scryptSync(secretKey, salt, 32);
 const iv = crypto.randomBytes(16);

 const cipher = crypto.createCipheriv('aes-256-cbc', key, iv);
 let encrypted = cipher.update(text, 'utf8', 'hex');
 encrypted += cipher.final('hex');
 return iv.toString('hex') + ':' + salt.toString('hex') + ':' + encrypted;
}

// Decrypt function
function decrypt(encryptedText, secretKey) {
 const parts = encryptedText.split(':');
 const iv = Buffer.from(parts[0], 'hex');
 const salt = Buffer.from(parts[1], 'hex');
 const encryptedData = parts[2];

 const key = crypto.scryptSync(secretKey, salt, 32);
 const decipher = crypto.createDecipheriv('aes-256-cbc', key, iv);
 let decrypted = decipher.update(encryptedData, 'hex', 'utf8');
 decrypted += decipher.final('utf8');
 return decrypted;
}

// Usage
const secretKey = 'Amar@1234!';
const plaintext = 'Amar@12345';

const encryptedData = encrypt(plaintext, secretKey);
//const encryptedData = '700550338c9f03689aba70842a294d26:151f0645de1a28193bf244b7907158be:acf297ace3b28a750ee887370d502eb7a0b0504299d55d7dd1f846d71a947a88'
console.log('Encrypted:', encryptedData);

const decryptedData = decrypt(encryptedData, secretKey);
console.log('Decrypted:', decryptedData);