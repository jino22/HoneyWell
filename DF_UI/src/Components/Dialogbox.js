

function Dialog(){
    return(
        <div 
        style={{
            position: "fixed",
            bacgroundColor: "rgba(0,0,0,0.5)"
        }}
            >
            <div style={{
                display :"flex",
                alignItems:"center",
                justifyContent:"center",
                top:"50%",
                left:"50%",
                bacgroundColor:"white",
               position:"absolute",
               padding:"50px",
               transform:"translate(-50,-50)"
            }}
            >
                <h3 style={{color:'#111'}}>{dfgh}</h3>
                <div>
                    <button style={{bacgroundColor:"red"}}>ok</button>
                    <button style={{bacgroundColor:"red"}}>cancel</button>
                </div>
      </div>
      </div>

    );
}
export default Dialog;