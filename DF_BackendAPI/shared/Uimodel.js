"use strict";




const mongoose = require('mongoose');

const Schema = require("mongoose").Schema;




const modelSchema = new Schema({

    id: {

        type: Number

      },    

      timestamp: {    

         type: String

     },    

     currentjobstatus: {    

         type: String    

     },    

     timer: {    

         type: Number    

     },

     timertype : {

        type: String,

     

     },

     sensor: {    

        type: String    

    },

    simulatorname: {    

        type: String    

    }

   

});

//sensorhealthSchema.plugin(mongoosePaginate);

module.exports = mongoose.model('tests', modelSchema);