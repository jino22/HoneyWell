import React, { useEffect, useState } from "react"
import TablePagination from '@mui/material/TablePagination'
import ArrowDownwardIcon from '@mui/icons-material/ArrowDownward';
import ArrowUpwardIcon from '@mui/icons-material/ArrowUpward';
import '../headermain.css'
import { Box } from "@mui/system";
import Button from '@mui/material/Button';
// import axios from 'axios'

function Table({data}){
    const[asdesc,setasdesc]=useState(data) 
    const[image,setImage] = useState(<ArrowDownwardIcon/>)
    const [flag,setFlag]= useState(true)
    const [page, setPage] = React.useState(0)
  const [rowsperPage, setRowsperPage] = React.useState(10)
    const handleChangePage = (event, newPage) => {
        setPage(newPage)
      }
    
      const handleChangeRowsPerPage = (event) => {
        setRowsperPage(+event.target.value)
        setPage(0)
      }

    console.log("dataaaa", data)
    function sortTable(n,img) {
        var table,
          rows,
          switching,
          i,
          x,
          y,
          shouldSwitch,
          dir,
          switchcount = 0;
        table = document.getElementById("myTable");
        switching = true;
        //Set the sorting direction to ascending:
        dir = "asc";
        /*Make a loop that will continue until
        no switching has been done:*/
        
        {flag==true?setImage(<ArrowUpwardIcon/>):setImage(<ArrowDownwardIcon/>)}
        setFlag(!flag)
        while (switching) {
          //start by saying: no switching is done:
          switching = false;
          rows = table.getElementsByTagName("TR");
          /*Loop through all table rows (except the
          first, which contains table headers):*/
          for (i = 0; i < rows.length - 1; i++) { //Change i=0 if you have the header th a separate table.
            //start by saying there should be no switching:
            shouldSwitch = false;
            /*Get the two elements you want to compare,
            one from current row and one from the next:*/
            x = rows[i].getElementsByTagName("TD")[n];
            y = rows[i + 1].getElementsByTagName("TD")[n];
            /*check if the two rows should switch place,
            based on the direction, asc or desc:*/
            if (dir == "asc") {
              if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                //if so, mark as a switch and break the loop:
                shouldSwitch = true;
                break;
              }
            } else if (dir == "desc") {
              if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
                //if so, mark as a switch and break the loop:
                shouldSwitch = true;
                break;
              }
            }
          }
          if (shouldSwitch) {
            /*If a switch has been marked, make the switch
            and mark that a switch has been done:*/
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
            //Each time a switch is done, increase this count by 1:
            switchcount++;
          } else {
            /*If no switching has been done AND the direction is "asc",
            set the direction to "desc" and run the while loop again.*/
            if (switchcount == 0 && dir == "asc") {
              dir = "desc";
              switching = true;
            }
          }
        }
      }
      
    
    // useEffect(()=>{
    //     axios.get("https://datafactory001.azurewebsites.net/Data")
    //     .then(res=>console.log("api",res))
    //     .catch(err=>console.log(err))
    // })
    //const [tabledata, setTabledata] = useState()
    console.log('current date :', data)
    return(
        <>
          <div>
            <Box sx={{ display: "flex" }}>
           <table  style={{ marginTop: "30px" }} id="myTable">
                  <thead className="tableheader" disablePadding >
                      <th >Floor<Button style={{color:'white',marginRight:'10px'}} onClick={()=>sortTable(0,{flag})}>{image} </Button>  </th>
                      <th>  Room<Button style={{color:'white'}} onClick={()=>sortTable(1,{flag})}>{image} </Button></th>
                      <th>  Humidity<Button style={{color:'white'}} onClick={()=>sortTable(2,{flag})}>{image} </Button> </th>
                      <th>  Temperature<Button style={{color:'white'}} onClick={()=>sortTable(3,{flag})}>{image} </Button> </th>
                      <th>  Indoor Air quality(IAQ)<Button style={{color:'white'}} onClick={()=>sortTable(4,{flag})}>{image} </Button> </th>
                      <th>  Time Stamp<Button style={{color:'white'}} onClick={()=>sortTable(5,{flag})}>{image} </Button> </th>
                      <th>  Sensor<Button style={{color:'white'}} onClick={()=>sortTable(6,{flag})}>{image} </Button>  </th>
                  </thead>
                  <tbody>
                      {data && data.slice(page*rowsperPage,page*rowsperPage+rowsperPage).map((item) => {
                          let timeat = item.timestamp.slice(0,10)+'  '+item.timestamp.slice(11,18)
                          return (
                              <tr>
                                  <td>{item.floor_ref_id}</td>
                                  <td>{item.room_ref_id}</td>
                                  <td>{item.humidity}</td>
                                  <td>{item.temperature}</td>
                                  <td>{item.iaq}</td>
                                  <td>{timeat}</td>
                                  <td style={{marginLeft:'70px'}}>{item.sensor}</td>
                              </tr>
                          )
                      }
                      )}
                  </tbody>
              </table>
              </Box>
              
              <TablePagination
              rowsPerPageOptions={[10, 25, 100]}
             
              count={data?.length}
              
              page={page}
              rowsPerPage={rowsperPage}
              component="div"
              onPageChange={handleChangePage}
              onRowsPerPageChange={handleChangeRowsPerPage}
              style={{ marginRight: '129px'}}
            />
              </div>
              

        </>
    )
}
export default Table;