import Report from './Reports'
import '../headermain.css'
import Box from '@mui/material/Box';
import Sidebar from '../SideNavBar/Sidebar';
function Reportinfo(){
    return(
        <Box sx={{ display: 'flex' }}>
            <Sidebar/>
<div>
            <Report />
            </div>           
        </Box>
    )
    
}
export default Reportinfo