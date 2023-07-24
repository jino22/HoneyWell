import { useState, useEffect } from "react";
import axios from "axios";

import "../headermain.css";
import SingleSimulatorDetails from "./simulatorvcode";
import {
    Grid
  } from '@material-ui/core/'
export default function ImgMediaCard() {
  const [carddata, setCarddata] = useState([]);

  useEffect(() => {
    axios
      .get("https://datafactory001.azurewebsites.net/Ui")
      .then((res) => setCarddata(res.data))
      .catch((err) => console.log(err));
  }, []);

  return (
    <div style={{ marginTop: "100px" }}>
        <Grid
    container
    spacing={5}
    direction="row"
    justify="flex-start"
    alignItems="flex-start"
>
      {carddata?.map((item) => {
        
        return <SingleSimulatorDetails item={item} />;
        // </Grid>
      })}
      </Grid>
    </div>
  );
}