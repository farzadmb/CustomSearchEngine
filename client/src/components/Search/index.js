import React from 'react';

import Request from './Request';
import Result from './Result';
import { Box, Separator } from './styled';

const Search = (props) => {
    return (
        <Box>
            <Request />
            <Separator />
            <Result />
        </Box>
    );
};

export default Search;