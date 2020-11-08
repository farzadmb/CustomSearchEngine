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
    border-radius: 3px;
    border: 2px solid DarkCyan;
    margin: 0.5em 1em;
    padding: 0.25em 1em 0.25em 1em;    
    height: 30px;
    width: 15%;
`;

export { Border, Input, Button };