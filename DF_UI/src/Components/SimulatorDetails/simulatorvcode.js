import React from "react";
import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import Button from "@mui/material/Button";
import react, { useState,useEffect } from 'react'
import {
    Grid
  } from '@material-ui/core/'

const SingleSimulatorDetails = ({item}) => {


    const [singleData, setSingleData ] = useState(item)
    console.log("single Data", singleData);

  const handlebutton = (id) => {
    console.log("id", id);
    let dataWithThatID = singleData.filter(ele => ele._id === id);
    let dataWithoutThatID = singleData.filter(ele => ele._id !== id);
    let datawehavetoput = dataWithThatID.currentjobstatus === "Stoped" ?  {...dataWithThatID, currentjobstatus: "Running"} : {...dataWithThatID, currentjobstatus: "Stoped"}
    let tempData = {...dataWithoutThatID, ...datawehavetoput}
    setSingleData(tempData)
  };

  return (
    // <Grid item xs={12} sm={6} md={3}>
  
    <Grid item xs={12} sm={6} md={3}>
    <Card
      style={{
        width: "100%",
        marginRight: "100px",
        marginBottom: "5px",
        float: "left",
      }}
      sx={{ maxWidth: 345 }}
    >
      <CardContent style={{ width: "105%", paddingLeft: "-16px" }}>
        <table>
          <thead>
            <tr>
              <th colspan="2" style={{ backgroundColor: "#87CEEB" }}>
                {" "}
                {singleData.simulatorname}
              </th>
            </tr>
          </thead>
          <tr>
            <th>Sensor</th>
            <th> Time Interval</th>
          </tr>
          <tr style={{ backgroundColor: "#FFFFE0" }}>
            <th>{singleData.sensor}</th>
            <th>{singleData.timer} {singleData.timertype}</th>
          </tr>
          <tr style={{ backgroundColor: "white" }}>
            <th>Running Status</th>
            <th style={{color:singleData.currentjobstatus=="Running"?"green":"red"}}> {singleData.currentjobstatus}</th>
          </tr>
          <tr>
            <th></th>
            <th>
            <th><Button variant="outlined" id={singleData._id}  onClick={ singleData => handlebutton(singleData?._id)}
              >{singleData.currentjobstatus =="Stoped"?"Start":"Stop"}</Button></th>
              
            </th>
          </tr>
        </table>
      </CardContent>
    </Card>
    </Grid>
  );
  
};

export default SingleSimulatorDetails;
