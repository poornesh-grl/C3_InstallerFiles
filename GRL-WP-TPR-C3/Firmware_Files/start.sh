#/bin/sh
#ifconfig eth0 add 192.168.255.1
#modprobe zynq_remoteproc firmware=qiapp
modprobe zynq_remoteproc firmware=QiApp
sleep 1
modprobe rpmsg_user_dev_driver
sleep 1
mkdir -p /dev/gadget
mount -t gadgetfs gadgetfs /dev/gadget

cd
ethtool -s eth0 speed 100 duplex full autoneg on
sleep 10
udhcpc -x hostname:GRL_QI &
sleep 10

cp /mnt/Auth/openssl /usr/bin/.
cp /mnt/Auth/libcrypto.so.1.0.0 /lib/.
cp /mnt/Auth/libssl.so.1.0.0 /usr/lib/.

cp /mnt/Auth/ca.txt /bin
cp /mnt/Auth/cc.txt /bin
cp /mnt/Auth/cr.txt /bin
#cp /mnt/Auth/MCHP_WPCCA2_CERTIFICATE_SLOT1_002.txt /bin
#cp /mnt/Auth/R_LADYP_CERTIFICATE_001.txt /bin
cp /mnt/Auth/TestScript.sh /bin
cp /mnt/Auth/WPCCA3.cer /bin
cp /mnt/Auth/Auth.json /bin
cp /mnt/Auth/tempN.txt /bin
QiEthernetApp&

sleep 20
cd /bin
#./QiDisplayDebugApp&
./QiDisplayApp&

#QiEthernetDebugApp&
#sleep 13
#QiDisplayDebugApp&
#QiDisplayApp&
#usbipconfigapp&

#sleep 10
#broadcastapp&
#udhcpc&

