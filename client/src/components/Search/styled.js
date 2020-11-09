import styled from 'styled-components';

const Box = styled.div`
    text-align: center;
    width: 100%;
`;

const Separator = styled.div`
    border-top: 1px gray solid ;
    opacity: 0.4;
    width: 60%;
    align-items: center;    
    display: inline-block;
`;

const Header = styled.div`
    height: 120px;
    vertical-align: middle;
    position: relative;
`;

const Logo = styled.img`
    height: 60px;
    position: relative;
    top: 20%
`;

export { Box, Separator, Header, Logo };