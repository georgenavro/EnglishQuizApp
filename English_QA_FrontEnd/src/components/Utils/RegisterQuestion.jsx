import { TbPencilQuestion } from "react-icons/tb";

const RegisterQuestion = ({index,setFormData,formData}) =>{

   const handleChange = (e) => {
      const { name, value } = e.target;

    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));

     };
return (
<div className="registerInputs changeColor">
            <span className="icon"><TbPencilQuestion /></span>
         <input name={`MultipleAnswer0${index}`} value={formData[`MultipleAnswer0${index}`]} onChange={(e) =>handleChange(e)} type="text" placeholder={`Multiple Question ${index}`}/>
         </div> 
)
}
export default RegisterQuestion;
