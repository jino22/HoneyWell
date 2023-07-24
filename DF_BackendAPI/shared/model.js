"use strict";

const mongoose = require('mongoose');
const Schema = require("mongoose").Schema;

const modelSchema = new Schema({
    id: {
        type: String   
      },     
      floor_ref_id: {     
         type: String     
     },     
     room_ref_id: {     
         type: String     
     },    
     timestamp: {     
         type: String     
     },
     motion_detected : {
        type: Boolean,
        default : true
     },
    //  data: {     
    //      type: Object     
    //  },     
    //   body : {     
    //       type : Object     
    //   },     
    humidity: {     
         type: Number     
     },     
     temperature: {     
         type: Number     
     },
     iaq : {
        type: Number
     },
     sensor : {
        type: String
     },
     device_type : {
        type: String
     }
});
//sensorhealthSchema.plugin(mongoosePaginate);
const dataSchema = mongoose.model('simulators', modelSchema);
module.exports = {dataSchema}

