import styled from 'styled-components';

const Border = styled.div`
    height: 40px;
    width: 50%;
    text-align: center;
    display: inline-block;
`;

const Input = styled.input`
    font-size: 14px;
    padding-left: 4px;
    height: 30px;
    width: 30%;
    border-radius: 5px;
    outline: none;
    border: 1px solid #cfd2d4;
    margin-right: 5px;
`;

const Button = styled.button`
    background: DarkCyan;
    color: white;
    border-radius: 5px;
    border: 1px solid CadetBlue;
    padding: 0.25em 1em 0.25em 1em;    
    height: 35px;
    width: 17%;
    
    &:disabled {
        opacity: 0.5;
        cursor: not-allowed;
      }
`;

export { Border, Input, Button };