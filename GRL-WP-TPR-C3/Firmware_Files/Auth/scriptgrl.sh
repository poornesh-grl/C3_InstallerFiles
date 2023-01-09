#!/bin/bash

#############################################################################
# Custom Shell Script to add patch applied openssl into the petalinus build #
#############################################################################

echo "GRL : Adding openssl custom patch "

chmod 777 -R build/
cp ../../z_opesslpatch/openssl build/linux/rootfs/targetroot/bin/.
cp ../../z_opesslpatch/libcrypto.so.1.0.0 build/linux/rootfs/stage/lib/.
cp ../../z_opesslpatch/libcrypto.so.1.0.0 build/linux/rootfs/targetroot/lib/.
cp ../../z_opesslpatch/libssl.so.1.0.0 build/linux/rootfs/stage/usr/lib/.
cp ../../z_opesslpatch/libssl.so.1.0.0 build/linux/rootfs/targetroot/usr/lib/.

echo "**GRL : openssl patch added successfully** "


