import React from 'react';

import Request from './Request';
import Result from './Result';
import { Box, Separator, Header, Logo } from './styled';
import Sympli from '../../assets/sympli.png'

const Search = (props) => {
    return (
        <Box>
            <Header>
                <Logo src={Sympli} alt="website logo"/>
            </Header>
            <Request />
            <Separator />
            <Result />
        </Box>
    );
};

export default Search;