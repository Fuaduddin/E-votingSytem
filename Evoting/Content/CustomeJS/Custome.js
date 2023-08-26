
const tabbutton=document.querySelectorAll(".tab_button");
const tabbuttoncontainer=document.querySelectorAll(".tab_button_container");
tabbuttoncontainer.forEach((container,index)=>{
    if(index==0)
    {
        container.classList.add("activetab");
    }
    else{
        container.classList.remove("activetab");
    }
});
tabbutton.forEach((button,index)=>{
    button.addEventListener("click", ()=>{
        tabbuttoncontainer.forEach((container)=>{
            container.classList.remove("activetab");
        });
        tabbuttoncontainer[index].classList.add("activetab");
    });
});