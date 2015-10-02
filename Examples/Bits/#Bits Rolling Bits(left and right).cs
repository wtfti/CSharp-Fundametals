if (direction == "right")
                {
                    for (int rotation = 0; rotation < rotations; rotation++)
                    {
                        int firstBit = rowBit & 1;
                        rowBit >>= 1;
                        if (firstBit == 1)
                        {
                            rowBit |= (1 << 11);
                        }
                    }
                }
                else if(direction == "left")
                {
                    for (int rotation = 0; rotation < rotations; rotation++)
                    {
                        int lastBit = (rowBit >> 11) & 1;
                        rowBit <<= 1;
                        if (lastBit == 1 )
                        {
                            rowBit ^= (1 << 12);
                            rowBit |= 1;
                        }
                    }
                }