// import React from 'react'
// import './headermain.css'
// function Header(){
//     return(
//     <div className="headerc">
//         <h4>Honeywell Digital Factory</h4>

//     </div>
//     )
// }
// export default Header;
import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import  SideNavigation from './SideNavBar/Sidebar';

export default function ButtonAppBar() {
    const [state, setState] = React.useState({
        top: false,
        left: false,
        bottom: false,
        right: false,
      });
    
      const toggleDrawer = (anchor, open) => (event) => {
        if (event.type === 'keydown' && (event.key === 'Tab' || event.key === 'Shift')) {
          return;
        }
    
        setState({ ...state, [anchor]: open });
      };
  return (
    <Box sx={{ display: 'flex' }}>
      <AppBar style={{backgroundColor:"brown"}}  position="static">
        <Toolbar>
          <IconButton
            size="large"
            edge="start"
            color="inherit"
            aria-label="menu"
            sx={{ mr: 2 }}
            onClick={toggleDrawer("left", true)}
          >
            <MenuIcon />
          </IconButton>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
          Honeywell Digital Factory
          </Typography> 
          {/* <Button color="inherit">Login</Button> */}
         </Toolbar>
      </AppBar>
      {/* <SideNavigation/> */}
    </Box>
    
  );
  
}